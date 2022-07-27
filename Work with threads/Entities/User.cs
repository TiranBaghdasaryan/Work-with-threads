using System;

namespace Work_with_threads.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public DateTime Date { get; set; }
    }
}