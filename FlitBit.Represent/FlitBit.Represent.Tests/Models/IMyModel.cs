using System;
using FlitBit.Dto;

namespace FlitBit.Represent.Tests.Models
{
	[DTO]
	public interface IMyModel
	{
		DateTime Created { get; set; }
		int ID { get; set; }
		string Name { get; set; }
	}
}