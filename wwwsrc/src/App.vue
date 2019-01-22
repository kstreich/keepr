<template>
  <div id="app">

    <div class="row">
      <ul class="nav justify-content-center col-6">
        <li class="nav-item">
          <a class="nav-link active" href="#/">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#/userdash">UserDash</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Logout</a>
        </li>
      </ul>
      <p class="col-6 greeting">Hi, {{user.username}}</p>

    </div>
    <router-view />
  </div>
</template>


<script>

  export default {
    name: "Nav",
    computed: {
      user() {
        return this.$store.state.user
      },
    }
  };

</script>

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

  .greeting {
    display: flex;
    align-items: flex-end;
    margin: 0;
  }
</style>