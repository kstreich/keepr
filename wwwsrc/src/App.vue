<template>
  <div id="app">
    <ul class="nav justify-content-center">
      <li class="nav-item">
        <a class="nav-link active" href="#/">Home</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#/userdash">UserDash</a>
      </li>
      <!-- <li class="nav-item">
        <a class="nav-link" href="#">Random Link</a>
      </li> -->
    </ul>
    <router-view />
  </div>
</template>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  a {
    font-weight: bold;
    color: #2c3e50;
  }

  a.router-link-exact-active {
    color: #6fb897;
  }
</style>