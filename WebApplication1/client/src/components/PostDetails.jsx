import { ListGroup, ListGroupItem } from "reactstrap"
import { Post } from "./Post.jsx"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom"
import { getPost } from "../services/PostService.jsx"

export const PostDetails = () => {
    const [post, setPost] = useState({})

    const { id } = useParams();

    useEffect(() => {
        getPost(id).then(res => setPost(res))
    }, [id])

    return !post ?
        <div>loading</div>
    :
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12 col-lg-6">
                    <Post post={post} />
                    <ListGroup>
                        {post.comments?.map(c => {
                            <ListGroupItem>{c.message}</ListGroupItem>
                        })}
                    </ListGroup>
                </div>
            </div>
        </div>
}