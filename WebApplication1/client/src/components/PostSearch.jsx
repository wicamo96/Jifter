import { useEffect, useState } from "react"
import { Card, CardBody, CardTitle } from "reactstrap"
import { getAllPosts, searchPosts } from "../services/PostService.jsx"

export const PostSearch = ({ setPosts }) => {
    const [query, setQuery] = useState("")

    useEffect(() => {
        if (query === "") {
            getAllPosts().then(res => setPosts(res))
        } else {
            searchPosts(query).then(res => setPosts(res))
        }
    }, [query])

    return (
        <Card className="m-4">
            <CardTitle className="center margin">Search Posts</CardTitle>
            <CardBody className="flex-container-centered">
                <input placeholder="Search" onChange={(e) => setQuery(e.target.value)}></input>
            </CardBody>
        </Card>
    )
}