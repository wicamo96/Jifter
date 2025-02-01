import { useEffect } from "react"
import { useState } from "react"
import { getUserPosts } from "../services/PostService.jsx"
import { useParams } from "react-router-dom"
import { Post } from "./Post.jsx"

export const UserPosts = () => {
    const [userPosts, setUserPosts] = useState([])

    const { id } = useParams();

    useEffect(() => {
        getUserPosts(id).then(res => setUserPosts(res))
    }, [id])

    return !userPosts ?
    <div>loading</div>
    :
        <div className="container">
            <div className="row justify-content-center">
                <div className="cards-column">
                    {userPosts.map((post) => (
                        <Post key={post.id} post={post} />
                    ))}
                </div>
            </div>
        </div>
    
}