import { useEffect, useState } from "react"
import { Button, Card, CardBody, CardTitle } from "reactstrap"

export const PostForm = () => {
    const [post, setPost] = useState({})
    

    useEffect(() => {

    }, [])  

    return (
        <Card className="m-4">
            <CardTitle className="center margin">Create New Post</CardTitle>
            <CardBody className="flex-container-centered">
                <input placeholder="Post Title" onChange={(e) => {
                                                                        
                                                                }}
                ></input><br />
                <input placeholder="Add Image Url" onChange={(e) => }></input><br />
                <input placeholder="Add Caption" onChange={(e) => }></input><br />
                <Button>Submit</Button>
            </CardBody>
        </Card>
    )
}