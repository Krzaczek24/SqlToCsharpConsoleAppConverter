﻿using SqlToCsharpTranscriptor;

namespace SqlToCsharpConsoleAppConverter.Extensions
{
    internal static class ConverterExtensions
    {
        internal static CsharpClassesData ConvertToCsharpClasses(this SqlScriptData sqlScriptData, 
            string @namespace = null, 
            string baseClassName = null, 
            string baseClassNamespace = null, 
            string namePrefix = null, 
            string nameSuffix = null, 
            string childrenPropertyName = null,
            string accessModifier = null)
        {
            return sqlScriptData
                .ConvertToCsharpClasses()
                .SetNamespace(@namespace)
                .SetBaseClass(baseClassName)
                .SetBaseClassNamespace(baseClassNamespace)
                .SetNamePrefix(namePrefix)
                .SetNameSuffix(nameSuffix)
                .SetChildrenCollectionPropertyName(childrenPropertyName)
                .SetAccessModifier(accessModifier);
        }

        internal static CsharpClassesData ConvertToCsharpClassesUsingParams(this SqlScriptData sqlScriptData)
        {
            return sqlScriptData.ConvertToCsharpClasses(
                Parameters.Namespace,
                Parameters.BaseClassName,
                Parameters.BaseClassNamespace,
                Parameters.ClassPrefix,
                Parameters.ClassSuffix,
                Parameters.ChildrenPropertyName,
                Parameters.AccessModifier);
        }
    }
}
