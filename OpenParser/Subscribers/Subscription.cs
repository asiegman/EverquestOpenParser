﻿using System;

namespace OpenParser.Subscribers
{
    public abstract class Subscription<TEventResult> : ISubscription
    {
        protected Subscriber<TEventResult> Subscriber { get; set; }

        public virtual void Enable()
        {
            Subscriber.Enable();
        }

        public virtual void Disable()
        {
            Subscriber.Disable();
        }

        public void Subscribe()
        {
            Subscriber.Matched += Subscriber_Matched;
        }

        public event EventHandler<TEventResult> Matched;

        protected virtual void Subscriber_Matched(object sender, TEventResult e)
        {
            Matched?.Invoke(sender, e);
        }
    }
}