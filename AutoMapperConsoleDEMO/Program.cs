using AutoMapperConsoleDEMO.FlatteningDEMO;
using AutoMapperConsoleDEMO.ProjectionDEMO;
using AutoMapperConsoleDEMO.ConfigurationValidationDEMO;
using AutoMapperConsoleDEMO.ListsAndArraysDEMO;
using AutoMapperConsoleDEMO.NestedMappingsDEMO;
using AutoMapperConsoleDEMO.CustomtypeconvertersDEMO;
using AutoMapperConsoleDEMO.NullsubstitutionDEMO;
using AutoMapperConsoleDEMO.BeforeAndafterMapActionsDEMO;
using AutoMapperConsoleDEMO.MappingInheritanceDEMO;
using AutoMapperConsoleDEMO.ConditionalMappingDEMO;
using AutoMapperConsoleDEMO.OpenGenericsDEMO;
using AutoMapperConsoleDEMO.CustomvalueresolversDEMO;
using AutoMapperConsoleDEMO.ConfigurationDEMO;

namespace AutoMapperConsoleDEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            ////將複雜型別轉換成簡單型別
            //Flattening.FlatteningTest();
            ////改變對映的設定
            //Projection.ProjectionTest();
            ////檢查是否有欄位未對映
            //ConfigurationValidation.ConfigurationValidationTest();
            ////集合對映與多型態集合對映
            //ListsAndArrays.ListsAndArraysTest();
            //ListsAndArrays.ListsAndArrayselementtypesTest();
            ////巢狀對映
            //NestedMappings.NestedMappingsTest();
            ////自定義對映，可對映不同型別但相同名稱的屬性
            //Customtypeconverters.CustomtypeconvertersTest();
            ////值若為Null則給取代值
            //Nullsubstitution.NullsubstitutionTest();
            ////在對映之前或者對映之後做值的處理
            //BeforeAndafterMapActions.CustomtypeconvertersTest();
            ////對映繼承類別裡的屬性
            //MappingInheritance.MappingInheritanceTest();
            ////可設定條件，滿足條件才做對映
            //ConditionalMapping.ConditionalMappingTest();
            ////可對映泛型的欄位
            //OpenGenerics.OpenGenericsTest();
            ////自定義對映欄位的規則
            //Customvalueresolvers.CustomvalueresolversTest();
            ////可變換屬性名稱
            //Configuration.ConfigurationTest();
        }
    }
}
