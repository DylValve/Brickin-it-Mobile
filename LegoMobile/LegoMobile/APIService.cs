using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LegoMobile
{
    public class APIService
    {
        Users.User currentUser;

        public bool loggedIn;

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

                currentUser = new Users.User(login.data.id, login.data.name, email, login.data.token);

                if (login.success == true)
                {
                    loggedIn = true;
                    return login.success;
                }
                else
                {
                    return false;
                }
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

                currentUser = new Users.User(register.data.id, register.data.name, email, register.data.token);

                if (register.success == true)
                {
                    loggedIn = true;
                    return register.success;
                }
                else
                {
                    return false;
                }
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


                    if (logout.success == true)
                    {
                        loggedIn = false;
                        return logout.success;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        /// Sets
        public async Task<Sets.Set> ShowSet(string setNumer)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/sets/look-up-by/number/" + setNumer); // Create Http Request
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
            Sets.Set setResponse = JsonConvert.DeserializeObject<Sets.Set>(content);

            JToken jtoken = JsonConvert.DeserializeObject<JToken>(content);

            setResponse.SetNumber = jtoken.Value<string>("set_number");

            return setResponse;
        }

        public async Task<Collections.Collection> ShowCollection(string collectionNumber)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/collections/" + collectionNumber); // Create Http Request
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
            Collections.Collection collectionResponse = JsonConvert.DeserializeObject<Collections.Collection>(content);

            return collectionResponse;
        }

        public async Task<Sets.Set> ShowSetBarcode(string barcode)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/sets/look-up-by/barcode/" + barcode); // Create Http Request
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
            Sets.Set setResponse = JsonConvert.DeserializeObject<Sets.Set>(content);

            JToken jtoken = JsonConvert.DeserializeObject<JToken>(content);

            setResponse.SetNumber = jtoken.Value<string>("set_number");

            return setResponse;
        }

        public async Task<bool> DeleteSet(string setNumer)
        {
            try
            {
                var client = new HttpClient(); /// get the client id

                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://brickin-it.herokuapp.com/api/sets/" + setNumer); // Create Http Request
                var response = await client.SendAsync(requestMessage);

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
        }

        public async Task<Sets.Set> ShowSetInCollection(string setId)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/sets/" + setId); // Create Http Request
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
            Sets.Set setResponse = JsonConvert.DeserializeObject<Sets.Set>(content);

            return setResponse;
        }



        public async Task<bool> CreateSet(string name, string setNumber, Stream picture, int themeId, string barcode)
        {
            string pictureName = await UploadImage(picture);

            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(setNumber), "set_number");
                form.Add(new StringContent(pictureName), "picture");
                form.Add(new StringContent(themeId.ToString()), "theme_id");
                form.Add(new StringContent(barcode), "barcode");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/sets", form);// // sending the http response from brickin-it

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
                Sets.Set sets = JsonConvert.DeserializeObject<Sets.Set>(content);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<string> UploadImage(Stream picture)
        {
            var client = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data
            form.Add(new StreamContent(picture), "file", "photo");

            var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/store-file", form);// // sending the http response from brickin-it

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
            UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(content);

            return userResponse.file_name;
        }




        public async Task<List<Collections.Collection>> ShowCollections()
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/collections/user/" + currentUser.Id);
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

            List<Collections.Collection> collectionList = JsonConvert.DeserializeObject<List<Collections.Collection>>(content);

            return collectionList;
        }

        public async Task<bool> CreateCollections(string name)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data
                form.Add(new StringContent(name), "name");
                form.Add(new StringContent(currentUser.Id.ToString()), "user_id");
                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/collections", form);// // sending the http response from brickin-it

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it
                Collections.Collection collection = JsonConvert.DeserializeObject<Collections.Collection>(content);
                //Sets.Set sets = JsonConvert.DeserializeObject<Sets.Set>(content);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteCollections(string collectionId)
        {
            try
            {
                var client = new HttpClient(); /// get the client id

                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://brickin-it.herokuapp.com/api/collections/" + collectionId);
                var response = await client.SendAsync(requestMessage);

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }



        public async Task<List<Sets.Set>> ShowCollectionSets(string collectionId)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/collections/sets/" + collectionId);
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

            List<Sets.Set> setList = JsonConvert.DeserializeObject<List<Sets.Set>>(content);

            return setList;
        }

        public async Task<int> ShowCollectionSetId(string setId, string collectionId)
        {
            var client = new HttpClient(); /// get the client id

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://brickin-it.herokuapp.com/api/collections/alt-show/" + setId + "/" + collectionId);
            var response = await client.SendAsync(requestMessage);

            string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

            Collections.CollectionSet collectionSet = JsonConvert.DeserializeObject<Collections.CollectionSet>(content);

            return collectionSet.Id;
        }

        public async Task<bool> DeleteCollectionSet(int collectionId)
        {
            try
            {
                var client = new HttpClient(); /// get the client id

                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "https://brickin-it.herokuapp.com/api/collection-sets/" + collectionId);
                var response = await client.SendAsync(requestMessage);

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> CreateSetInCollection(string setId, string collectionId)
        {
            try
            {
                var client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent(); // creating form and filling with data
                form.Add(new StringContent(setId), "set_id");
                form.Add(new StringContent(collectionId), "collection_id");

                var response = await client.PostAsync("https://brickin-it.herokuapp.com/api/collection-sets", form);// // sending the http response from brickin-it

                string content = await response.Content.ReadAsStringAsync();// getting the http response from brickin-it

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
