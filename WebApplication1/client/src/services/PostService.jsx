const baseUrl = 'https://localhost:5001/api/Post';

export const getAllPosts = () => {
  return fetch(`${baseUrl}/GetWithComments`) 
    .then((res) => res.json())
};

export const addPost = (singlePost) => { 
  return fetch(`${baseUrl}/Add`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(singlePost),
  });
};

export const searchPosts = (query) => {
  return fetch(`${baseUrl}/search?q=${query}`)
    .then(res => res.json())
}

export const getPost = (id) => {
  return fetch(`${baseUrl}/${id}`).then(res => res.json())
}

export const getUserPosts = (userId) => {
  return fetch(`https://localhost:5001/api/UserProfile/GetUserPostsWithComments/${userId}`).then(res => res.json())
}