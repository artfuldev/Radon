using System.Threading.Tasks;
using AutoMapper;
using Radon.Core.Representations;

namespace Radon.Server.Responses
{
    public static class ApiResultExtensions
    {
        private static readonly IMappingEngine Mapper = AutoMapper.Mapper.Engine;

        public static ApiResult<T> AsApiResult<T>(this ApiResponse<T> source) where T : IRepresentation
        {
            return new ApiResult<T>(source);
        }

        public static async Task<ApiResult<T>> AsApiResult<T>(this Task<ApiResponse<T>> source) where T : IRepresentation
        {
            return new ApiResult<T>(await source);
        }

        public static ApiResult<T> AsApiResult<T>(this T dto) where T : IRepresentation
        {
            return new ApiResult<T>(dto.AsApiResponse());
        }

        public static async Task<ApiResult<T>> AsApiResult<T>(this Task<T> dtoTask) where T : IRepresentation
        {
            return await dtoTask.AsApiResponse().AsApiResult();
        }

        public static ApiResult<IPagedCollection<T>> AsPagedApiResult<T>(
            this IRepresentationCollection<T> collection) where T : IRepresentation
        {
            return Mapper.Map<IPagedCollection<T>>(collection).AsApiResult();
        }
    }
}