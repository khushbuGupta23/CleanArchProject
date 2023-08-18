using Dapper;
using signzy.Infrastucture.Interfaces;

namespace signzy.Application
{
    public class ApiServiceBase
    {
        #region Protected fields

        /// <summary>
        /// The dapper repository
        /// </summary>
        protected readonly IDapperRepository _dapperRepository;

        #endregion

        #region Constructors   

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiServiceBase"/> class.
        /// </summary>
        /// <param name="dapperRepository">The dapper repository.</param>
        public ApiServiceBase(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Processes the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="storeProcName">Name of the store procedure.</param>
        protected void ProcessData<T>(DynamicParameters paramName, string storeProcName)
        {
            try
            {

                _dapperRepository.Execute(storeProcName, paramName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected T InsertData<T>(string storeProcName, DynamicParameters paramName)
        {
            try
            {

                return _dapperRepository.Insert<T>(storeProcName, paramName);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected T GetData<T>(DynamicParameters paramName, string storeProcName)
        {
            try
            {
                return _dapperRepository.Get<T>(storeProcName, paramName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected List<T> GetAllDataById<T>(string storeProcName, DynamicParameters paramName)
        {
            try
            {
                return _dapperRepository.GetAll<T>(storeProcName, paramName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected  int ExecuteAsync(string storeProcName, DynamicParameters paramName)
        {
            try
            {
                return  _dapperRepository.Execute(storeProcName, paramName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected List<T> GetAllData<T>(string storeProcName)
        {
            try
            {
                return _dapperRepository.GetAll<T>(storeProcName, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected T UpdateData<T>(DynamicParameters paramName, string storeProcName)
        {
            try
            {

                return _dapperRepository.Update<T>(storeProcName, paramName);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
