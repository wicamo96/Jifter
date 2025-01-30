import React, { useState, useEffect } from "react";
import { getAllPosts } from "../services/PostService";
import { Post } from "./Post";
import { PostForm } from "./PostForm.jsx";
import { PostSearch } from "./PostSearch.jsx";

export const PostList = () => {
  const [posts, setPosts] = useState([]);

  const getPosts = () => {
    getAllPosts().then(allPosts => setPosts(allPosts)); 
  };

  useEffect(() => {
    getPosts();
  }, []); 
  
  return (
    <div className="container">
      <div className="row justify-content-center">
        <div className="cards-column">
          <PostSearch setPosts={setPosts} />
          {posts.map((post) => (
            <Post key={post.id} post={post} />
          ))}
          <PostForm getPosts={getPosts}/>
        </div>
      </div>
    </div>
  );
};
