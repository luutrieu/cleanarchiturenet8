﻿using Application.DTOs.Request.Account;
using Application.DTOs.Response;
using Application.DTOs.Response.Account;
using Application.Extensions;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AccountService(HttpClientService httpClientService) : IAccountService
    {
        public Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            throw new NotImplementedException();
        }

        public Task CreateAdmin()
        {
            throw new NotImplementedException();
        }

        public Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetRoleDTO>> GetRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetUsersWithRolesResponseDTO>> GetUserWithRolesAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        //{
        //    try
        //    {
        //        var publicClient = httpClientService.GetPubliceClient();
        //        var response = await publicClient.PostAsJsonAsync(Constant.LoginRoute, model);
        //        string error = CheckResponseStatus(response);
        //        if (!string.IsNullOrEmpty(error))
        //            return new LoginResponse(Flag: false, Message: error);

        //        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new LoginResponse(Flag: false, Message: ex.Message);
        //    }
        //}
        public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPubliceClient();
                var response = await publicClient.PostAsJsonAsync(Constant.LoginRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(Flag: false, Message: error);

                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result;
            }
            catch (Exception ex)
            {
                return new LoginResponse(Flag: false, Message: ex.Message);
            }
        }

        //public Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<GeneralResponse> RegisterAccountAsync(CreateAccountDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPubliceClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(Flag: false, Message: error); ;

                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponse(Flag: false, Message: ex.Message);
            }
        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return $"Sorry unknown error occured. {Environment.NewLine} Error Description:{Environment.NewLine} Status code: {response.StatusCode}{Environment.NewLine}Reason Phrase: {response.ReasonPhrase}";
            else
                return null!;
        }

        public async Task CreateAdminAtFirstStart()
        {
            try
            {
                var client = httpClientService.GetPubliceClient();
                await client.PostAsync(Constant.CreateAdminRoute, null);
            }
            catch { }
        }

        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetRoleDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public IEnumerable<GetRoleDTO> GetDefaultRoles()
        //{
        //    var list = new List<GetRoleDTO>();
        //    list?.Clear();
        //    list.Add(new GetRoleDTO(1.ToString(),Constant.Role.Admin));
        //    list.Add(new GetRoleDTO(2.ToString(),Constant.Role.User));
        //    return list;
        //}

        public async Task<IEnumerable<GetUsersWithRolesResponseDTO>> GetUsersWithRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetuserWithRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);

                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetUsersWithRolesResponseDTO>>();
                return result!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<GeneralResponse> ChangeUserRole(ChangeUserRoleRequestDTO model)
        {
            try
            {
                var publicClient= await httpClientService.GetPrivateClient();
                var respone = await publicClient.PostAsJsonAsync(Constant.ChangeUserRoleRoute, model);
                var error = CheckResponseStatus(respone);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(false, error);

                var result = await respone.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPubliceClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RefreshTokenRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(false, error);

                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }
    }
}
