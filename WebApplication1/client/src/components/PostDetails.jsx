import { ListGroup, ListGroupItem } from "reactstrap"
import { Post } from "./Post.jsx"

export const PostDetails = () => {
    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-sm-12 col-lg-6">
                    <Post post={post} />
                    <ListGroup>
                        {post.comments.map(c => {
                            <ListGroupItem>{c.message}</ListGroupItem>
                        })}
                    </ListGroup>
                </div>
            </div>
        </div>
    )
}