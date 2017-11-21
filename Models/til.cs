using System;


namespace tilrepo.Models
{
    public class til
    {
        public int id { get; set; }
        public string content  { get; set; }

        private string _tags = string.Empty;
        public string tags
        {
            get { return _tags;}
            set { _tags = value;}
        }
        

        private string _reference = string.Empty;
        public string reference
        {
            get { return _reference;}
            set { _reference = value;}
        }
        

        private DateTime _addedOn = DateTime.Now;
        public DateTime addedOn
        {
            get { return _addedOn;}
            set { _addedOn = value;}
        }
        

    }
}