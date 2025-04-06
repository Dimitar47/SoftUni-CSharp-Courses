namespace Infrastructure.Data.Common
{
    /// <summary>
    /// Функции и съхранени процедури в базата данни
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Име на функция за теглене на служители
        /// </summary>
        private const string GetEmployeesByOffice = "get_employees(@p1)";

        /// <summary>
        /// Имена на съхранени процедури
        /// </summary>
        private static readonly IReadOnlyDictionary<ProcedureType, string> procedureNames = new Dictionary<ProcedureType, string>
        {
            { ProcedureType.GetEmployeesByOffice, GetEmployeesByOffice }
        };

        /// <summary>
        /// Получаване на име на съхранена процедура
        /// </summary>
        /// <param name="procedure">Стойност от енумерация за тип процедура / функция</param>
        /// <returns></returns>
        public static string GetProcedureName(ProcedureType procedure)
        {
            return procedureNames[procedure];
        }
    }

    /// <summary>
    /// Типове съхранени процедури
    /// </summary>
    public enum ProcedureType
    {
        GetEmployeesByOffice
    }
}
