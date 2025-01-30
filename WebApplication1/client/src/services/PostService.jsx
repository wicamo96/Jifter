const baseUrl = 'https://localhost:5001/api/Post';

export const getAllPosts = () => {
  return fetch(baseUrl) 
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