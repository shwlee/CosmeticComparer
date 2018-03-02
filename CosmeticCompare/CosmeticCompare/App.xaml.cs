using CosmeticCompare.Interfaces;
using CosmeticCompare.Models;
using CosmeticCompare.MVVM;
using Newtonsoft.Json;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CosmeticCompare
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			var locator = ContainerResolver.GetContainer();
			locator.RegisterType<IEventAggregator, EventAggregator>();

			ProductRepository repository = null;
			if (File.Exists(ConstSet.SaveFileName) == false)
			{
				using (File.Create(ConstSet.SaveFileName))
				{
				}

				repository = new ProductRepository();
			}
			else
			{
				var readJson = File.ReadAllText(ConstSet.SaveFileName);
				repository = JsonConvert.DeserializeObject<ProductRepository>(readJson);
			}

			if (repository == null)
			{
				repository = new ProductRepository();
			}

			locator.RegisterInstance(typeof(IRepository), repository);

			base.OnStartup(e);
		}
	}
}
