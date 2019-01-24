<template>
  <div id="app">

    <div class="row">
      <ul class="nav justify-content-center col-lg-6 col-md-6 col-sm-12">
        <li class="nav-item">
          <a class="nav-link active" href="#/">Home</a>
        </li>
        <li v-if="user.id" class="nav-item">
          <a class="nav-link" href="#/userdash">UserDash</a>
        </li>
        <li v-if="user.id" class="nav-item">
          <a @click="logout" class="nav-link" href="#">Logout</a>
        </li>
        <li v-else class="nav-item">
          <a class="nav-link" href="#/login">Log In</a>
        </li>

      </ul>

      <a v-if="user.id" class="col-lg-6 col-md-6 col-sm-12 greeting nav-item nav-link">Hi, {{user.username}}</a>

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
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
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
    /* font-weight: bold; */
    color: #000000;

  }

  a.router-link-exact-active {
    color: #6fb897;
  }

  a:hover {
    text-decoration: none;
    color: black
  }

  .greeting {
    display: flex;
    align-items: flex-end;
    /* margin: 0; */
    justify-content: flex-end;
  }

  .btn {
    color: black;
  }
</style>