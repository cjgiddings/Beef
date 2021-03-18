﻿using Beef.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beef.Events.UnitTest
{
    [TestFixture]
    public class EventDataMapperTest
    {
        [Test]
        public void SubjectOnly()
        {
            var ed = EventData.CreateEvent("Subject");
            var eh = ed.ToEventHubsEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.ActionPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.TenantIdPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = eh.ToBeefEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual(null, ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(null, ed.Key);
        }

        [Test]
        public void SubjectAndAction()
        {
            var ed = EventData.CreateEvent("Subject", "Action");
            var eh = ed.ToEventHubsEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectPropertyName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.TenantIdPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = eh.ToBeefEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(null, ed.Key);
        }

        [Test]
        public void SubjectActionAndKey()
        {
            var id = Guid.NewGuid();

            var ed = EventData.CreateEvent("Subject", "Action", id);
            Assert.IsNotNull(ed.EventId);
            var eid = ed.EventId;
            var eh = ed.ToEventHubsEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual(eid, eh.Properties[EventMetadata.EventIdPropertyName]);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectPropertyName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.TenantIdPropertyName]);
            Assert.AreEqual(id, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = eh.ToBeefEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual(eid, ed.EventId);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(id, ed.Key);
        }

        [Test]
        public void SubjectActionAndArrayKey()
        {
            var id = Guid.NewGuid();
            var no = 123;

            var ed = EventData.CreateEvent("Subject", "Action", id, no);
            var eh = ed.ToEventHubsEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectPropertyName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.TenantIdPropertyName]);
            Assert.AreEqual(id, ((object[])eh.Properties[EventMetadata.KeyPropertyName])[0]);
            Assert.AreEqual(no, ((object[])eh.Properties[EventMetadata.KeyPropertyName])[1]);

            ed = eh.ToBeefEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(id, ((object[])ed.Key)[0]);
            Assert.AreEqual(no, ((object[])ed.Key)[1]);
        }

        public class Person : IGuidIdentifier
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public void SubjectActionKeyAndValue()
        {
            var p = new Person { Id = Guid.NewGuid(), Name = "Caleb" };

            var ed = EventData.CreateValueEvent(p, "Subject", "Action");
            var eh = ed.ToEventHubsEventData();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", eh.Properties[EventMetadata.SubjectPropertyName]);
            Assert.AreEqual("Action", eh.Properties[EventMetadata.ActionPropertyName]);
            Assert.AreEqual(null, eh.Properties[EventMetadata.TenantIdPropertyName]);
            Assert.AreEqual(p.Id, eh.Properties[EventMetadata.KeyPropertyName]);

            ed = eh.ToBeefEventData<Person>();
            Assert.IsNotNull(eh);
            Assert.AreEqual("Subject", ed.Subject);
            Assert.AreEqual("Action", ed.Action);
            Assert.AreEqual(null, ed.TenantId);
            Assert.AreEqual(p.Id, ed.Key);
            Assert.IsNotNull(ed.Value);
            Assert.AreEqual(p.Id, ed.Value.Id);
            Assert.AreEqual(p.Name, ed.Value.Name);
        }
    }
}