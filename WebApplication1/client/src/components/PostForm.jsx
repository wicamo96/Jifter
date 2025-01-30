import { useState } from "react"
import { Button, Card, CardBody, CardTitle } from "reactstrap"
import { addPost } from "../services/PostService.jsx"

export const PostForm = ({ getPosts }) => {
    const [post, setPost] = useState({})

    return (
        <Card className="m-4">
            <CardTitle className="center margin">Create New Post</CardTitle>
            <CardBody className="flex-container-centered">
                <input id="postTitle" placeholder="Post Title" onChange={(e) => {
                                                                    let tmp = {...post}
                                                                    tmp.title = e.target.value
                                                                    setPost(tmp)
                                                                }}
                ></input><br />
                <input id="postImageUrl" placeholder="Add Image Url" onChange={(e) => {
                                                                        let tmp = {...post}
                                                                        tmp.imageUrl = e.target.value
                                                                        setPost(tmp)
                                                                    }}
                ></input><br />
                <input id="postCaption" placeholder="Add Caption" onChange={(e) => {
                                                                        let tmp = {...post}
                                                                        tmp.caption = e.target.value
                                                                        setPost(tmp)
                                                                    }}
                ></input><br />
                <Button onClick={() => {
                                        addPost(post)
                                        getPosts()
                                        document.getElementById("postTitle").value = ''
                                        document.getElementById("postImageUrl").value = ''
                                        document.getElementById("postCaption").value = ''
                                        }}
                >Submit</Button>
            </CardBody>
        </Card>
    )
}