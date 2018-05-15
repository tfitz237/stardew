﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;
using StardewValley.MPSaveEditor.Commands;

namespace StardewValley.MPSaveEditor
{
    class Program
    {
        static Dictionary<int, string> Commands = new Dictionary<int, string> {
            { 0, "Farmhand Management System (FMS)"},
            { 1, "Close"}
        };
        static int Main(string[] args)
        {   



            var app = new CommandLineApplication();
            app.HelpOption();
            app.ThrowOnUnexpectedArgument = false;
            var programArgument = app.Argument("program", "Select the program you would like to run");  
            app.OnExecute(() => SelectProgram(programArgument));
            return app.Execute(args);

        }
        public static void SelectProgram(CommandArgument programArgument) 
        {
            Console.WriteLine("Stardew Valley Multiplayer Save Editor");
            Console.WriteLine("--------------------------------------");
            var program = 0;
            if (programArgument.Value == null) {           
                foreach (var command in Commands) {
                    Console.WriteLine($"{command.Key}.   {command.Value}");
                }   
                program = Prompt.GetInt("Select a program:", 0);
            } else {
                program = Commands.ContainsValue(programArgument.Value) ? Commands.First(x => x.Value == programArgument.Value).Key : -1;
            }
            switch(program) {
                case 0:
                    CommandLineApplication.Execute<FarmhandManagementCommand>();
                    SelectProgram(programArgument);
                    break;
                case 1:
                    break;
                
            }

        }
        
    }
}
