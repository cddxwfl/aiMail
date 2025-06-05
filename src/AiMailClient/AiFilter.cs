using System.Collections.Generic;
using System.Linq;

namespace AiMailClient
{
    public class AiFilter
    {
        public IEnumerable<MailMessage> Filter(IEnumerable<MailMessage> messages, string keyword)
        {
            // Simple placeholder filter: return messages containing keyword
            return messages.Where(m => m.Body.Contains(keyword, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
