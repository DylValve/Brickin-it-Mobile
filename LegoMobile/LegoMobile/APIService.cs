using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LegoMobile
{
    public class APIService
    {
        User currentUser;

        /// <summary>
        /// This code fetches the API
        /// </summary>
        public async Task<bool> LoginRequest(string email, string password)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(email), "email");
                form.Add(new StringContent(password), "password");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/login", form); // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync(); // getting the http response from brickin-it 
                UserResponse login = JsonConvert.DeserializeObject<UserResponse>(content);

                currentUser = new User(login.data.name, email, login.data.token);

                if (login.success)
                {
                    return login.success;
                }
                return login.success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> RegisterRequest(string name, string email, string password, string confirm_password)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(email), "email");
                form.Add(new StringContent(password), "password");
                form.Add(new StringContent(confirm_password), "confirm_password");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/register", form);// // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                UserResponse register = JsonConvert.DeserializeObject<UserResponse>(content);

                currentUser = new User(register.data.name, email, register.data.token);

                if (register.success)
                {
                    return register.success;
                }
                return register.success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> LogoutRequest()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://brickin-it.herokuapp.com/api/logout"); // Create Http Request
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", currentUser.Token); // Token Authentication 

                    var response = await client.SendAsync(requestMessage); // Send Request

                    string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                    UserResponse logout = JsonConvert.DeserializeObject<UserResponse>(content);

                    if (logout.success)
                    {
                        return logout.success;
                    }
                    return logout.success;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public async Task<bool> CreateSet(string name, string set_number, string picture, int theme_id)
        {
            try
            {
                var sets = new HttpSets();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data 
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(set_number), "set_number");
                form.Add(new StringContent(picture), "picture");
                form.Add(new StringContent(theme_id), "theme_id");

                var response = await client.PostAsync("http://brickin-it.herokuapp.com/api/sets", form);// // sending the http response from brickin-it 

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                Set sets = JsonConvert.DeserializeObject<Set>(content);

                if (sets.success)
                {
                    return sets.success;
                }
                return sets.success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }


        
            
        }

        public async Task<bool> viewSet()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://brickin-it.herokuapp.com/api/sets"); // Create Http Request
                    

                    var response = await client.SendAsync(requestMessage); // Send Request

                    string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it 
                    Set viewSets = JsonConvert.DeserializeObject<Set>(content);

                    if (viewSets.success)
                    {
                        return viewSets.success;
                    }
                    return viewSets.success;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
    }

}
