using System;
using System.Collections.Generic;
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

    [DTO]
    public interface IComplexModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
        ISubModel Model { get; set; }
    }

    [DTO]
    public interface ISubModel
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }

    [DTO]
    public interface IArrayBasedModel : ISubModel
    {
        IEnumerable<IArrayItemModel> Items { get; set; }
    }

    [DTO]
    public interface IArrayItemModel 
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        string Name { get; set; }
    }
}