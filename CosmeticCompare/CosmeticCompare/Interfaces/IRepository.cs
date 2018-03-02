using CosmeticCompare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticCompare.Interfaces
{
    public interface IRepository
    {
		void Add(Cosmetic cosmetic);

		void Remove(Cosmetic cosmetic);

		void Save();
	}
}
