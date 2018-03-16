using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.BLL;
using Data.IBLL;
using System.Reflection;
using Autofac.Integration.Mvc;

namespace NHibernateDemo.Common
{
    public class AutoFacFactory
    {
        public ContainerBuilder builder;
        public IContainer container;
        public AutoFacFactory()
        {
            builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            Add(builder);
            container = builder.Build();
        }
        public void Add(ContainerBuilder builder)
        {
           builder.RegisterType<Student_BLL>().As<IStudent_BL>().AsImplementedInterfaces();
        }
    }
}