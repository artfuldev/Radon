using System;
using System.Threading.Tasks;
using Radon.Core.Errors;
using Radon.Core.Representations;

namespace Radon.Server.Responses
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> AsApiResponse<T>(this T dto) where T : IRepresentation
        {
            return new ApiResponse<T>(dto);
        }



        public static async Task<ApiResponse<T>> AsApiResponse<T>(this Task<T> dtoTask) where T : IRepresentation
        {
            try
            {
                return new ApiResponse<T>(await dtoTask);
            }
            catch (ApiException ex)
            {
                return new ApiResponse<T>(new ApiError(ex));
            }
            catch (AggregateException ex)
            {
                return new ApiResponse<T>(new ApiError(ex));
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>(new ApiError(ex));
            }
        }
    }
}
