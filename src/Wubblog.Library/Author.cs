﻿using System;

namespace Wubblog.Library
{
	public class Author
	{
		#region Constructors
		
		public Author() {}
		
		public Author(string userName, string password)
		{
			this.UserName = userName;
			this.PasswordHash = PasswordHasher.CreateHash(password);
		}
		
		#endregion
		
		#region Properties
		
		public int AuthorId { get; set; }
		
		public string UserName { get; set; }
		
		public string DisplayName { get; set; }
		
		public string PasswordHash { get; set; }
		
		#endregion
		
		#region Methods
		
		public bool ValidatePassword(string password)
		{
			return PasswordHasher.ValidateHash(password, this.PasswordHash);
		}
		
		public void ResetPassword(string password)
		{
			this.PasswordHash = PasswordHasher.CreateHash(password);
		}
		
		public void Save()
		{
			if(this.AuthorId == 0)
				DbFactory.Db.Authors.Insert(this);
			else
				DbFactory.Db.Authors.Update(this);
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
		#region Static
		
		public static Author FindById(int id)
		{
			return DbFactory.Db.Authors.FindByAuthorId(id);
		}
		
		#endregion
	}
}
