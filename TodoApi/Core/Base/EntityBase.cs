using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Core.Base {
    public interface IEntityBase<TKey> {
        TKey Id { get; set; }
    }

    public interface IDeleteBase {
        bool IsDeleted { get; set; }
    }

    public interface IAuditBase {
        string UpdatedBy { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }

    public interface IAuditBase<TKey> : IAuditBase, IDeleteBase<TKey> {
    }
    public interface IDeleteBase<TKey> : IDeleteBase, IEntityBase<TKey> {
    }


    public abstract class EntityBase<TKey> : IEntityBase<TKey> {
        [Key]
        public virtual TKey Id { get; set; }
    }

    public abstract class DeleteBase<TKey> : EntityBase<TKey>, IDeleteBase<TKey> {
        public bool IsDeleted { get; set; }
    }

    public abstract class AuditBase<TKey> : DeleteBase<TKey>, IAuditBase<TKey> {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}