import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import UserDash from './views/UserDash.vue'

// @ts-ignore
import Vault from './views/Vault.vue'

// @ts-ignore
import Keep from './views/Keep.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      //Home with all of the keeps
      path: '/',
      name: 'home',
      component: Home
    },
    {
      //Main login page, create by teachers
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      //This will show all of the users vaults
      path: '/userDash',
      name: 'userDash',
      component: UserDash,
      props: true
    },
    {
      //A specific vault which will show all of the keeps
      path: '/vault/:vaultId',
      name: "vault",
      component: Vault,
      props: true
    },
    {
      path: '/keep/:keepId',
      name: "keep",
      component: Keep,
      props: true
    },
    {
      path: "*",
      redirect: '/'

    }
  ]
})
