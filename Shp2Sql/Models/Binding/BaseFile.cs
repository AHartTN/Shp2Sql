using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shp2Sql.Models.Binding
{
	public class BaseFile : BaseModel
	{
		public BaseFile()
		{

		}

		public BaseFile(FileInfo file)
		{
			CreationTime = file.CreationTime;
			CreationTimeUtc = file.CreationTimeUtc;
			DirectoryName = file.DirectoryName;
			Extension = file.Extension;
			FullName = file.FullName;
			IsReadOnly = file.IsReadOnly;
			LastAccessTime = file.LastAccessTime;
			LastAccessTimeUtc = file.LastAccessTimeUtc;
			LastWriteTime = file.LastWriteTime;
			LastWriteTimeUtc = file.LastWriteTimeUtc;
			Length = file.Length;
			Name = file.Name;
			Exists = file.Exists;
		}

		public DateTime CreationTime { get; set; }

		public DateTime CreationTimeUtc { get; set; }

		[Required]
		[StringLength(1024)]
		public string DirectoryName { get; set; }

		[Required]
		[StringLength(8)]
		public string Extension { get; set; }

		public bool Exists { get; set; }

		[Required]
		[StringLength(1024)]
		public string FullName { get; set; }

		public bool IsReadOnly { get; set; }

		public DateTime LastAccessTime { get; set; }

		public DateTime LastAccessTimeUtc { get; set; }

		public DateTime LastWriteTime { get; set; }

		public DateTime LastWriteTimeUtc { get; set; }

		public long Length { get; set; }

		[Required]
		[StringLength(1024)]
		public string Name { get; set; }
	}
}
