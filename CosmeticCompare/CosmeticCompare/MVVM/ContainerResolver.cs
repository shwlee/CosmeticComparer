using CosmeticCompare.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticCompare.MVVM
{
	public class ContainerResolver
	{
		private static readonly Lazy<ComponentContainer> LazyComponentContainer = new Lazy<ComponentContainer>(() => new ComponentContainer());

		public static IComponentContainer GetContainer()
		{
			return LazyComponentContainer.Value;
		}
	}
}
