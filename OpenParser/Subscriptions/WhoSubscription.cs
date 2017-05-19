using System.Text.RegularExpressions;
using OpenParser.EventResults;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions
{
    public class WhoSubscription : Subscription<Who>
    {
        public WhoSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Who>(logFile,
                new RegexStrategy<Who>(CompiledRegex.WhoRegex, HandleMatches));
            Subscribe();
        }


        private Who HandleMatches(LogEntry entry, Match match)
        {
            var name = match.Groups["name"].ToString();
            var guild = match.Groups["guild"].ToString();
            var zone = match.Groups["zone"].ToString();
            
            return new Who(entry, name, guild, zone);
        }
    }
}