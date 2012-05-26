#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector.Uhn
{
	/// <summary>
	/// Defines a rule that replaces the value of the DicomTag for the specified AETitle.
	/// </summary>
	public class TagReplacementRule
	{
		/// <summary>
		/// The AETitle of the calling MWL client
		/// </summary>
		public string AETitle;

		/// <summary>
		/// The DICOM tag of the attribute that is to have its value replaced.
		/// </summary>
		public uint DicomTag;

		/// <summary>
		/// The new replacement value.
		/// </summary>
		public string NewValue;
	}

	/// <summary>
	/// A singleton class that helps to convert text-based settings into a list of tag replacement rules.
	/// </summary>
	/// <remarks>
	/// The expected format for each rule is: AETitle, (GroupString, ElementString), "New Value"
	/// Comments can be added following "--".
	/// </remarks>
	public class TagReplacementSettingsHelper
	{
		#region Singleton Stuff

		private static TagReplacementSettingsHelper _instance;

		private TagReplacementSettingsHelper()
		{
			_rules = LoadSettings();
		}

		public static TagReplacementSettingsHelper Instance
		{
			get
			{
				if (_instance == null)
					_instance = new TagReplacementSettingsHelper();

				return _instance;
			}
		}

		#endregion

		private readonly List<TagReplacementRule> _rules;

		/// <summary>
		/// Gets a list of rules for the specified AETitle.
		/// </summary>
		public List<TagReplacementRule> GetRulesForAETitle(string modalityAETitle)
		{
			return CollectionUtils.Select(_rules,
				delegate(TagReplacementRule rule)
				{
					return rule.AETitle == modalityAETitle;
				});
		}

		private static List<TagReplacementRule> LoadSettings()
		{
			List<TagReplacementRule> rules = new List<TagReplacementRule>();

			try
			{
				using (StringReader reader = new StringReader(MwlFilterSettings.Default.TagReplacementRules))
				{
					string line = reader.ReadLine();
					while (line != null)
					{
						List<string> tokens = ParseLine(line);

						// We expect each line to have exactly 4 elements separated by commas
						// AETitle, (group, element), "New value"
						if (tokens.Count == 4)
						{
							TagReplacementRule rule = new TagReplacementRule();
							rule.AETitle = tokens[0];
							rule.DicomTag = GetTagValue(tokens[1], tokens[2]);
							rule.NewValue = tokens[3].Trim('"');

							rules.Add(rule);
						}

						line = reader.ReadLine();
					}
				}

			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e);
			}

			return rules;
		}

		/// <summary>
		/// Parse a line by stripping comments that starts with "--"  and returns a list of string tokens separated by commas.
		/// Each token will be trimmed of spaces, tabs and round brackets.
		/// </summary>
		private static List<string> ParseLine(string line)
		{
			if (string.IsNullOrEmpty(line))
				return new List<string>();

			// Remove comments and split by comma
			const string comments = "--";
			int commentStartsAt = line.IndexOf(comments);
			string[] splitTokens = commentStartsAt < 0
			                       	? line.Split(',')
			                       	: line.Remove(commentStartsAt).Split(',');

			// Trim white spaces, tabs and round brackets from the beginning and end of each token
			List<string> tokens = new List<string>();
			foreach (string token in splitTokens)
				tokens.Add(token.Trim(' ', '\t', '(', ')'));

			return tokens;
		}

		/// <summary>
		/// Returns a uint DICOM tag value.  The input group and element should be hexadecimal value in string format.
		/// </summary>
		private static uint GetTagValue(string groupString, string elementString)
		{
			ushort group;
			ushort element;
			ushort.TryParse(groupString, NumberStyles.HexNumber, null, out group);
			ushort.TryParse(elementString, NumberStyles.HexNumber, null, out element);
			return DicomTag.GetTagValue(group, element);
		}
	}
}
