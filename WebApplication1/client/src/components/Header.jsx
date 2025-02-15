import { Link } from "react-router-dom"

export const Header = () => {
    return (
        <nav className="navbar navbar-expand navbar-dark bg-info">
            <Link to='/' className="navbar-brand">
                Jifter
            </Link>
            <ul className="navbar-nav mr-auto">
                <li className="nav-item">
                    <Link to='/' className="nav-link">
                        Feed
                    </Link>
                </li>
                <li>
                    <Link to='/posts/add' className="nav-link">
                        New Post
                    </Link>
                </li>
            </ul>
        </nav>
    )
}