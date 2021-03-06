﻿using System.Text.RegularExpressions;
using OpenParser.EventResults.Combat;
using OpenParser.Filters;
using OpenParser.SubscriberStrategies;

namespace OpenParser.Subscriptions.Melee
{
    public class PhysicalHitSubscription : Subscription<Combat<DamageInfo>>
    {
        public PhysicalHitSubscription(LogFile logFile) : base(logFile)
        {
            Subscriber = new Subscriber<Combat<DamageInfo>>(logFile,
                new RegexStrategy<Combat<DamageInfo>>(CompiledRegex.DamageRegex, HandleMatches));
            Subscribe();
        }


        private Combat<DamageInfo> HandleMatches(LogEntry entry, Match match)
        {
            var attacker = match.Groups[1].Value.AttemptCharacterNameReplace(LogFile.Character);
            var target = match.Groups[3].Value.AttemptCharacterNameReplace(LogFile.Character);
            var damageType = match.Groups[2].Value;

            long damage;
            long.TryParse(match.Groups[4].Value, out damage);

            return new Combat<DamageInfo>(entry, attacker, target, new DamageInfo(damage, damageType));
        }
    }
}