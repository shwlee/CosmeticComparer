using CosmeticCompare.Interfaces;
using CosmeticCompare.MVVM;
using CosmeticCompare.PubSub;
using Prism.Events;

namespace CosmeticCompare.ViewModels
{
	public class MainViewModel : ObservableObject
	{
		public IContent ViewContent { get; set; }

		public MainViewModel()
		{
			this.ViewContent = ViewModelLocator.GetViewModel<CompareViewModel>();

			var locator = ContainerResolver.GetContainer();
			var eventAggregator = locator.Resolve<IEventAggregator>();
			var pub = eventAggregator.GetEvent<ChangeViewModel>();
			pub.Subscribe(this.SetViewModel, ThreadOption.PublisherThread);
		}

		private void SetViewModel(ViewFrames view)
		{
			switch (view)
			{
				case ViewFrames.Compare:
					this.ViewContent = ViewModelLocator.GetViewModel<CompareViewModel>();
					break;
				case ViewFrames.Register:
					this.ViewContent = ViewModelLocator.GetViewModel<RegisterViewModel>();
					break;
			}
		}
	}
}
