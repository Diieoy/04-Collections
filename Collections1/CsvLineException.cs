using System;

namespace Collections1.CsvExceptions
{
    class CsvException : Exception
    {
        private string csvString;

        public string CsvString { get => csvString; set => csvString = value; }

        public CsvException(string csvString, string message) : base(message)
        {
            this.csvString = csvString;
        }
    }
}
