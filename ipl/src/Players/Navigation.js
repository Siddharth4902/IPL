import { Link } from "react-router-dom";

export default function PlayerNavigation() {
  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
      <div className="container-fluid">
        <h1 className="navbar-brand">IPL</h1>
        
    <div className="navbar-nav">
      <Link to="/" className="nav-link">
        Home
      </Link>
      <Link to="/players" className="nav-link " >Player List</Link>
      <Link to="/top5" className="nav-link">Top5 List</Link>
      <Link to="/matches" className="nav-link">Match List</Link>
      <Link to="/daterange" className="nav-link">Date range</Link>
      <Link to="/players/add" className="nav-link" >Add Player</Link>
      </div>
      </div>
      
    </nav>
  );
}
