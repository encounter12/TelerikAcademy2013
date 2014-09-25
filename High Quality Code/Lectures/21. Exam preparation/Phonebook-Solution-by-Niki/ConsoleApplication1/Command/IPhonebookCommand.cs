namespace Phonebook.Command
{
    using System;
    using System.Linq;

    public interface IPhonebookCommand
    {
        void Execute(string[] arguments);
    }
}
