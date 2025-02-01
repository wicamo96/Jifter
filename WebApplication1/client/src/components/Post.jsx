import React from "react";
import { Card, CardImg, CardBody } from "reactstrap";
import { Link } from "react-router-dom";


export const Post = ({ post }) => {
  return !post ?
    <div>loading</div>
  :
    <Card className="m-4">
      <p className="text-left px-2">Posted by: <Link to={`/users/${post.userProfileId}`}>{post.userProfile?.name}</Link></p>
      <CardImg top src={post.imageUrl} alt={post.title} />
      <CardBody>
        <p>
          <Link to={`/posts/${post.id}`}>
            <strong>{post.title}</strong>
          </Link>
        </p>
        <p>{post.caption}</p>
        <strong>Comments: </strong>
        {post.comments?.length > 0 ? 
        post.comments.map(comment => {
          return <p>{comment.message}</p>
        })
        :
        <></>
        }
      </CardBody>
    </Card>
};