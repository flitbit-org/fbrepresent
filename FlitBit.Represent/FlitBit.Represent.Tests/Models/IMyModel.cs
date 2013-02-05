using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlitBit.Dto;

namespace FlitBit.Represent.Tests.Models
{
	[DTO]
	public interface IMyModel
	{
		int ID { get; set; }
		string Name { get; set; }
		DateTime Created { get; set; }
	}
}
