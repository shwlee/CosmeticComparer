using CosmeticCompare.Interfaces;
using CosmeticCompare.Models;
using CosmeticCompare.MVVM;
using CosmeticCompare.PubSub;
using Prism.Events;
using System;
using System.Windows.Input;

namespace CosmeticCompare.ViewModels
{
	public class RegisterViewModel : ObservableObject, IContent
	{
		public string BrandName { get; set; }

		public string ProductName { get; set; }

		public string Ingredient { get; set; }

		#region Commands

		private RelayCommand _registerCommand;

		public ICommand RegisterCommand
		{
			get { return this._registerCommand ?? (this._registerCommand = new RelayCommand(this.Register)); }
		}

		private void Register(object obj)
		{			
			var ingredientsSplit = Ingredient.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
			var newCosmetic = new Cosmetic
			{
				BrandName = this.BrandName,
				ProductName = this.ProductName,
				Ingredients = ingredientsSplit
			};

			var locator = ContainerResolver.GetContainer();
			var repository = locator.Resolve<IRepository>();
			repository.Add(newCosmetic);
			repository.Save();

			var eventAggregator = locator.Resolve<IEventAggregator>();
			eventAggregator.GetEvent<ChangeViewModel>().Publish(ViewFrames.Compare);
		}

		#endregion
	}
}
