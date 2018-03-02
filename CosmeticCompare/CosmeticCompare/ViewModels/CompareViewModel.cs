using CosmeticCompare.Interfaces;
using CosmeticCompare.MVVM;
using CosmeticCompare.PubSub;
using Prism.Events;
using System.Windows.Input;

namespace CosmeticCompare.ViewModels
{
	public class CompareViewModel : ObservableObject, IContent
	{
		public string SearchText { get; set; }

		#region Commands

		private RelayCommand _goRegisterCommand;

		public ICommand GoRegisterCommand
		{
			get { return this._goRegisterCommand ?? (this._goRegisterCommand = new RelayCommand(this.GoRegister)); }
		}

		private void GoRegister(object obj)
		{
			var locator = ContainerResolver.GetContainer();
			var eventAggregator = locator.Resolve<IEventAggregator>();
			eventAggregator.GetEvent<ChangeViewModel>().Publish(ViewFrames.Register);
		}

		#endregion
	}
}
