﻿namespace Busniess.Interfaces;
public interface IFileServices
{
  IEnumerable<IUserModel> LoadFromFile();
  bool SaveToFile(IUserModel users);
}
