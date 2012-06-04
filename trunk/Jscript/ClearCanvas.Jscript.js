import System;
import System.Collections;

import ClearCanvas.Common;
import ClearCanvas.Common.Scripting;

[assembly: ClearCanvas.Common.Plugin()]

package ClearCanvas.Jscript
{
    /// This class provides an implementation of ClearCanvas.Common.Scripting.ScriptEngineExtensionPoint
    /// for JScript
    ///
    /// The values in the context IDictionary are accessible to the script as 
    /// both globals (actually locals in the context of the script function) and as properties of "this".
    /// For example, if the dictionary contains "name" => "JoJo", then from the script,
    ///
    ///     name => "JoJo"          (entries are accessible as "global" variables)
    ///     or
    ///     this.name => "JoJo"     (the entries are directly accessible as properties of this)
    ///
    /// The script must use the "return" keyword to return an object to the caller. This is because
    /// the Run(...) method packages the script into its own function before executing it.
    public 
    ClearCanvas.Common.ExtensionOf(ScriptEngineExtensionPoint)
    ClearCanvas.Common.Scripting.LanguageSupport("jscript")
    class Engine implements IScriptEngine
    {
	    function Run(script: String, context: IDictionary)
	    {
			var variableNames = new String[context.Count];

			var i = 0;
 	        for(var entry in context)
	        {
	            variableNames[i++] = entry.Key;
	        }
	        var es = CreateScriptPrivate(script, variableNames);
	        return es.Run(context);
	    }
	    
        function CreateScript(script: String, variableNames: String[]) : IExecutableScript
        {
			return CreateScriptPrivate(script, variableNames);
        }
        
        private function CreateScriptPrivate(script, variableNames) : ExecutableScript
        {
			var header = "";
			
			for(var i=0; i < variableNames.length; i++)
			{
				header += "var " + variableNames[i] + " = this." + variableNames[i] + ";";
			}
 	        var ctx = {};
	        ctx.__scriptFunction__ = new Function(header + script);
	        return new ExecutableScript(ctx);
        }
    }
    
    internal class ExecutableScript implements IExecutableScript
    {
        private var _ctx;
        
        // constructor 
        function ExecutableScript(ctx)
        {
            _ctx = ctx;
        }
        
        function Run(context: IDictionary)
        {
 	        for(var entry in context)
	        {
	            _ctx[entry.Key] = entry.Value;
	        }
	        return _ctx.__scriptFunction__();
        }
    }
}