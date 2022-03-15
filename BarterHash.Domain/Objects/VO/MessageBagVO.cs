using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarterHash.Domain.Objects.VO
{
    public class MessageBagVO
    {
        // Isso funcionaria?
        public MessageBagVO(int @ref, string title, bool isError)
        {
            Ref = @ref; // Por que tem @?
            Title = title;
            IsError = isError;
        }
        public MessageBagVO(List<string> messages)
        {
            Messages = messages;
        }
        public MessageBagVO(string message)
        {
            Messages = new List<string>() { message };
        }

        public int Ref { get; set; }
        public List<string> Messages { get; set; }
        public string Title { get; set; }
        public bool IsError { get; set; }

    }
}
