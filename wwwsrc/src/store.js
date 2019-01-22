import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    Allkeeps: [],
    UserVaults: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setAllKeeps(state, keeps) {
      state.Allkeeps = keeps
    },
    setVaultsByUser(state, vaults) {
      state.UserVaults = vaults
    }

  },
  actions: {

    //VAULTS
    getAllVaults({ commit, dispatch }, userId) {
      api.get('/user/' + userId)
        .then(res => {
          console.log(res)
          commit('setVaultsByUser', res.data)
        })
    },

    //KEEPS
    getAllKeeps({ commit, dispatch }) {
      api.get('/keeps')
        .then(res => {
          console.log(res)
          commit('setAllKeeps', res.data)
        })
    },


    //AUTH 
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    }
  }
})