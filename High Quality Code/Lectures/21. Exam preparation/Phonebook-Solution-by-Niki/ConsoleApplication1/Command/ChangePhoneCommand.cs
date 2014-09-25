namespace Phonebook.Command
{
    using System;
    using System.Linq;

    public class ChangePhoneCommand : IPhonebookCommand
    {
        private IPrinter printer;
        private IPhonebookRepository data;
        private IPhoneNumberSanitizer sanitizer;

        public ChangePhoneCommand(IPhonebookRepository data, IPrinter printer, IPhoneNumberSanitizer sanitizer)
        {
            this.printer = printer;
            this.data = data;
            this.sanitizer = sanitizer;
        }

        public void Execute(string[] arguments)
        {
            var currentPhoneNumber = this.sanitizer.Sanitize(arguments[0]);
            var newPhoneNumber = this.sanitizer.Sanitize(arguments[1]);
            var phoneNumbersChanged = this.data.ChangePhone(currentPhoneNumber, newPhoneNumber);
            var textToPrint = phoneNumbersChanged + " numbers changed";
            this.printer.Print(textToPrint);
        }
    }
}