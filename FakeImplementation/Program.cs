using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

static class Program
{
    static int Main(string[] args)
    {
        if ((args == null) || (args.Length == 0))
        {
            return 1;
        }
        try
        {
            foreach (FileInfo fileInfo in GetFiles())
            {
                AssemblyDef assemblyDef = AssemblyDef.Load(ReadAllBytes());
                using (ModuleDef moduleDef = assemblyDef.ManifestModule)
                {
                    foreach (CilBody body in moduleDef.GetTypes().Where(typeDef => typeDef.HasMethods).SelectMany(typeDef => (from methodDef in typeDef.Methods where methodDef.HasBody select methodDef.Body)))
                    {
                        if (body.HasExceptionHandlers)
                        {
                            body.ExceptionHandlers.Clear();
                        }
                        if (body.HasVariables)
                        {
                            body.Variables.Clear();
                        }
                        if (body.HasInstructions)
                        {
                            body.Instructions.Clear();
                        }
                        body.KeepOldMaxStack = true;
                    }
                    {
                        FileInfo outputFileInfo = new FileInfo(Path.Combine(fileInfo.DirectoryName ?? String.Empty, Path.GetFileNameWithoutExtension(fileInfo.Name) + "-preview" + fileInfo.Extension));
                        if (outputFileInfo.Exists)
                        {
                            outputFileInfo.Delete();
                        }
                        ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(moduleDef)
                                                                  {
                                                                      PdbFileName = Path.ChangeExtension(outputFileInfo.FullName, "xml"),
                                                                      WritePdb = File.Exists(Path.ChangeExtension(fileInfo.FullName, "xml"))
                                                                  };
                        moduleDef.Write(outputFileInfo.FullName, moduleWriterOptions);
                        if (moduleWriterOptions.WritePdb)
                        {
                            File.Copy(Path.ChangeExtension(fileInfo.FullName, "xml"), moduleWriterOptions.PdbFileName, true);
                        }
                    }
                }

                byte[] ReadAllBytes()
                {
                    using (FileStream fileStream = fileInfo.OpenRead())
                    {
                        byte[] buffer = new byte[fileStream.Length];
                        fileStream.Read(buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine(ex.StackTrace);
            return 2;
        }
        return 0;

        IEnumerable<FileInfo> GetFiles()
        {
            foreach (FileInfo fileInfo in args.Select(fileName => new FileInfo(fileName)).Where(fileInfo => fileInfo.Exists))
            {
                yield return fileInfo;
            }
        }
    }
}