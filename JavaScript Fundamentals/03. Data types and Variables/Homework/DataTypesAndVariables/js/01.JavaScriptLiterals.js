/*jslint browser: true*/
/*global jsConsole, intLit, floatLit, stringLit, booleanLit, doe, arr*/

jsConsole.writeLine("Variable literal (number): " + intLit);
jsConsole.writeLine("Variable literal (number): " + floatLit);
jsConsole.writeLine("Variable literal (string): \"" + stringLit + "\"");
jsConsole.writeLine("Variable literal (boolean): " + booleanLit);
jsConsole.writeLine("Variable literal (object): " + doe.toString());
jsConsole.writeLine("Variable literal (array): " + arr.toString());