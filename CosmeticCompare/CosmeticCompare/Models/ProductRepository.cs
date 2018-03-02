using CosmeticCompare.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticCompare.Models
{
	public class ProductRepository : IRepository
	{
		public List<Cosmetic> Cosmetics { get; set; }

		public void Add(Cosmetic cosmetic)
		{
			this.CheckInit();

			// 이름이 같은 것만 비교한다.
			var alreadyExist = this.Cosmetics.FirstOrDefault(c => string.CompareOrdinal(c.BrandName, cosmetic.BrandName) == 0);
			if (alreadyExist != null)
			{
				// 같은 제품이 존재하면 교체한다.
				this.Cosmetics.Remove(alreadyExist);
			}

			this.Cosmetics.Add(cosmetic);
		}
		
		private void CheckInit()
		{
			if (this.Cosmetics == null)
			{
				this.Cosmetics = new List<Cosmetic>();
			}
		}

		public void Remove(Cosmetic cosmetic)
		{
			this.CheckInit();

			this.Cosmetics.Remove(cosmetic);
		}

		public void Save()
		{
			var serialized = JsonConvert.SerializeObject(this);
			File.WriteAllText(ConstSet.SaveFileName, serialized);
		}
	}
}
